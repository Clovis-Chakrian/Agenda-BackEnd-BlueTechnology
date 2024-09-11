using Agenda.Libs.Data;

namespace Agenda.Domain.Entities.Contacts;

public class Contact : BaseEntity
{
    public int ContactId { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}