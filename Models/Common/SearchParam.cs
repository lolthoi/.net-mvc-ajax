namespace Exam.Models.Common
{
    public class SearchParam
    {
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
        public string SearchText { get; set; } = string.Empty;
    }
}