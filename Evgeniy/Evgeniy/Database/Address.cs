using Starcounter;

namespace Evgeniy.Database
{
    [Database]
    public class Address
    {
        public int Number { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }

    }
}
