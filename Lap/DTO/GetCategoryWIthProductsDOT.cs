namespace Lap.DTO
{
    public class GetCategoryWIthProductsDOT
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public List<string>? products { get; set; }
    }
}
