namespace ORRA.Domain.Entities
{
    public class ImagingProcedureModifier
    {
        public int Id { get; set; }
        public string ModifierName { get; set; }
        public string ModifierCode { get; set; }
        public ImagingProcedureModifierType Type { get; set; }
    }
}