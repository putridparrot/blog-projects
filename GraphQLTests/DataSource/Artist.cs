using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public class Artist
    {
        public string Name { get; set; }

        public IEnumerable<Album> Albums { get; }
    }
}
