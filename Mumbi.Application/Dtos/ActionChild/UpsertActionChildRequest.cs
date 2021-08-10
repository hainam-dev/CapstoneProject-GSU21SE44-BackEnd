namespace Mumbi.Application.Dtos.ActionChild
{
    public class UpsertActionChildRequest
    {
        public string ChildId { get; set; }
        public int ActionId { get; set; }
        public bool CheckedFlag { get; set; }
    }
}