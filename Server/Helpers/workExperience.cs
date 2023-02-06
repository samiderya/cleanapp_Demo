using System.Collections.Generic;

namespace Server.Helpers
{
    internal class workExperience
    {
        public workExperience()
        {
           var choice =new choice(); 
        }
        public int id { get; set; }
        public string quation { get; set; }

        public choice choice { get; set; }
    }
     internal class choice
    {
        public List<string> answer { get; set; }
    }
}