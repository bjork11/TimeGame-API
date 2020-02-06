using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeGame_API.Models
{
    public class HighScoreItem
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int HighScoreInSeconds { get; set; }  
    }
}
