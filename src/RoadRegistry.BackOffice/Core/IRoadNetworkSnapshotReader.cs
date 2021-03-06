namespace RoadRegistry.BackOffice.Core
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRoadNetworkSnapshotReader
    {
        Task<(Messages.RoadNetworkSnapshot snapshot, int version)> ReadSnapshot(CancellationToken cancellationToken);
    }
}
