namespace CCB.SFMagentoIntegration.Functions.Models.Create
{
    internal class IncomingRequest
    {
        public int WebsiteId { get; set; }
        public int GroupId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
