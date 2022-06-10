namespace JagoRTT.domain.Enum.VM
{
    public class EnumTypeVM
    {
        public EnumTypeVM(string text, string value)
        {
            Value = value;
            Text = text;
        }

        public EnumTypeVM(string text, Guid valueId)
        {
            Value = valueId.ToString();
            Text = text;
        }

        public string Value { get; private set; }
        public string Text { get; private set; }
    }
}
