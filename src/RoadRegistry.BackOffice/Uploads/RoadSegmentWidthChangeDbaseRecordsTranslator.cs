namespace RoadRegistry.BackOffice.Uploads
{
    using System;
    using System.IO.Compression;
    using Be.Vlaanderen.Basisregisters.Shaperon;
    using Schema;

    public class RoadSegmentWidthChangeDbaseRecordsTranslator : IZipArchiveDbaseRecordsTranslator<RoadSegmentWidthChangeDbaseRecord>
    {
        public TranslatedChanges Translate(ZipArchiveEntry entry, IDbaseRecordEnumerator<RoadSegmentWidthChangeDbaseRecord> records, TranslatedChanges changes)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));
            if (records == null) throw new ArgumentNullException(nameof(records));
            if (changes == null) throw new ArgumentNullException(nameof(changes));

            while (records.MoveNext())
            {
                var record = records.Current;
                if (record != null)
                {
                    switch (record.RECORDTYPE.Value)
                    {
                        case RecordType.EqualIdentifier:
                        case RecordType.AddedIdentifier:
                        case RecordType.ModifiedIdentifier:
                            var segmentId = new RoadSegmentId(record.WS_OIDN.Value);
                            if (changes.TryFindAddRoadSegment(segmentId, out var before))
                            {
                                var width = new RoadSegmentWidthAttribute(
                                    new AttributeId(record.WB_OIDN.Value),
                                    new RoadSegmentWidth(record.BREEDTE.Value),
                                    RoadSegmentPosition.FromDouble(record.VANPOSITIE.Value),
                                    RoadSegmentPosition.FromDouble(record.TOTPOSITIE.Value)
                                );
                                changes = changes.Replace(before, before.WithWidth(width));
                            }
                            break;
                    }
                }
            }

            return changes;
        }
    }
}
