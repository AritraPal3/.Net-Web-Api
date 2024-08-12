namespace Capsitech.Models
{
    public class FormDataBaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CapdashCollections { get; set; } = null!;

        public string LogCollections { get; set; } = null!;

    }
}
