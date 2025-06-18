using SQLite;

namespace ListViewMAUI
{
    #region Contacts
    public class Contacts
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string? ContactName { get; set; }
        public string? ContactNumber { get; set; }
    }
    #endregion
}
