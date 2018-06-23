using System.Threading.Tasks;
using Grpc.Core;
using PutridParrot.Music;

namespace Server
{
    public class MusicServer : MusicService.MusicServiceBase
    {
        public override Task<NotesResponse> Query(NotesRequest request, ServerCallContext context)
        {
            if (request.Key == Note.C)
            {
                return Task.FromResult(new NotesResponse
                {
                    Name = request.Name,
                    Key = request.Key,
                    Notes =
                    {
                        Note.C, Note.E, Note.G
                    }
                });
            }
            return base.Query(request, context);
        }
    }
}
