namespace RoadRegistry.BackOffice.Messages
{
    using MessagePack;

    [MessagePackObject]
    public class RoadNetworkSnapshotSegment
    {
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int StartNodeId { get; set; }
        [Key(2)]
        public int EndNodeId { get; set; }
        [Key(3)]
        public RoadSegmentGeometry Geometry { get; set; }
        [Key(4)]
        public int AttributeHash { get; set; }
    }
}
