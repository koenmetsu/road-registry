namespace RoadRegistry.BackOffice.Uploads
{
    using System;
    using System.Collections.Generic;
    using System.IO.Compression;
    using Be.Vlaanderen.Basisregisters.Shaperon;
    using Schema;

    public class RoadSegmentLaneChangeDbaseRecordsValidator : IZipArchiveDbaseRecordsValidator<RoadSegmentLaneChangeDbaseRecord>
    {
        public ZipArchiveProblems Validate(ZipArchiveEntry entry, IDbaseRecordEnumerator<RoadSegmentLaneChangeDbaseRecord> records)
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
                            if (record.RS_OIDN.HasValue)
                            {
                                if (record.RS_OIDN.Value == 0)
                                {
                                    problems += recordContext.IdentifierZero();
                                }
                                else
                                {
                                    var identifier = new AttributeId(record.RS_OIDN.Value);
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
                                problems += recordContext.RequiredFieldIsNull(record.RS_OIDN.Field);
                            }

                            if (!record.AANTAL.HasValue)
                            {
                                problems += recordContext.RequiredFieldIsNull(record.AANTAL.Field);
                            }
                            else if (!RoadSegmentLaneCount.Accepts(record.AANTAL.Value))
                            {
                                problems += recordContext.LaneCountOutOfRange(record.AANTAL.Value);
                            }

                            if (!record.RICHTING.HasValue)
                            {
                                problems += recordContext.RequiredFieldIsNull(record.RICHTING.Field);
                            }
                            else if (!RoadSegmentLaneDirection.ByIdentifier.ContainsKey(record.RICHTING.Value))
                            {
                                problems += recordContext.LaneDirectionMismatch(record.RICHTING.Value);
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
