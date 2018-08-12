using System.Collections.Generic;

namespace GraphQLTests
{
    public class Artist
    {
        public string Name { get; set; }

        public IList<Album> Albums { get; set; }
    }

    public class Album
    {
        public string Title { get; set; }
    }
}
