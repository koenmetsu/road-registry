namespace RoadRegistry.BackOffice.Uploads
{
    using System;
    using System.Collections.Generic;
    using System.IO.Compression;
    using Be.Vlaanderen.Basisregisters.Shaperon;
    using Schema;

    public class RoadSegmentWidthChangeDbaseRecordsValidator : IZipArchiveDbaseRecordsValidator<RoadSegmentWidthChangeDbaseRecord>
    {
        public ZipArchiveProblems Validate(ZipArchiveEntry entry, IDbaseRecordEnumerator<RoadSegmentWidthChangeDbaseRecord> records)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));
            if (records == null) throw new ArgumentNullException(nameof(records));

            var problems = ZipArchiveProblems.None;

            try
            {
                var identifiers = new Dictionary<AttributeId, RecordNumber>();
                var moved = records.MoveNext();
                if (moved)
                {
                    while (moved)
                    {
                        var recordContext = entry.AtDbaseRecord(records.CurrentRecordNumber);
                        var record = records.Current;
                        if (record != null)
                        {
                            if (!record.RECORDTYPE.HasValue)
                            {
                                problems += recordContext.RequiredFieldIsNull(record.RECORDTYPE.Field);
                            } else
                            {
                                if (!RecordType.ByIdentifier.ContainsKey(record.RECORDTYPE.Value))
                                {
                                    problems += recordContext.RecordTypeMismatch(record.RECORDTYPE.Value);
                                }
                            }
                            if (record.WB_OIDN.HasValue)
                            {
                                if (record.WB_OIDN.Value == 0)
                                {
                                    problems += recordContext.IdentifierZero();
                                }
                                else
                                {
                                    var identifier = new AttributeId(record.WB_OIDN.Value);
                                    if (identifiers.TryGetValue(identifier, out var takenByRecordNumber))
                                    {
                                        problems += recordContext.IdentifierNotUnique(
                                            identifier,
                                            takenByRecordNumber
                                        );
                                    }
                                    else
                                    {
                                        identifiers.Add(identifier, records.CurrentRecordNumber);
                                    }
                                }
                            }
                            else
                            {
                                problems += recordContext.RequiredFieldIsNull(record.WB_OIDN.Field);
                            }

                            if (!record.BREEDTE.HasValue)
                            {
                                problems += recordContext.RequiredFieldIsNull(record.BREEDTE.Field);
                            }
                            else if (!RoadSegmentWidth.Accepts(record.BREEDTE.Value))
                            {
                                problems += recordContext.WidthOutOfRange(record.BREEDTE.Value);
                            }

                            if (!record.VANPOSITIE.HasValue)
                            {
                                problems += recordContext.RequiredFieldIsNull(record.VANPOSITIE.Field);
                            }
                            else if (!RoadSegmentPosition.Accepts(record.VANPOSITIE.Value))
                            {
                                problems += recordContext.FromPositionOutOfRange(record.VANPOSITIE.Value);
                            }

                            if (!record.TOTPOSITIE.HasValue)
                            {
                                problems += recordContext.RequiredFieldIsNull(record.TOTPOSITIE.Field);
                            }
                            else if (!RoadSegmentPosition.Accepts(record.TOTPOSITIE.Value))
                            {
                                problems += recordContext.ToPositionOutOfRange(record.TOTPOSITIE.Value);
                            }

                            if (!record.WS_OIDN.HasValue)
                            {
                                problems += recordContext.RequiredFieldIsNull(record.WS_OIDN.Field);
                            }
                            else if (!RoadSegmentId.Accepts(record.WS_OIDN.Value))
                            {
                                problems += recordContext.RoadSegmentIdOutOfRange(record.WS_OIDN.Value);
                            }
                        }
                        moved = records.MoveNext();
                    }
                }
                else
                {
                    problems += entry.HasNoDbaseRecords(false);
                }
            }
            catch (Exception exception)
            {
                problems += entry.AtDbaseRecord(records.CurrentRecordNumber).HasDbaseRecordFormatError(exception);
            }

            return problems;
        }
    }
}
