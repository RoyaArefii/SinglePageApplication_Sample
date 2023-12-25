namespace SinglePageApplication.Controllers.Dtos.PersonDtos
{
    public class SelectPersonDto
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string FullName { get { return $"{FName} {LName}"; } }
    }
}
