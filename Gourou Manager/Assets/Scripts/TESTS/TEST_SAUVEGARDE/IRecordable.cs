public interface IRecordable
{
    public int UUID { get; }
    
    public void recordSave(out string[] o_data);
}
