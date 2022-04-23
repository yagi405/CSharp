namespace NetOfficePoc.Excel
{
    public class ExcelOperationResult
    {
        public enum ResultType
        {
            Success
        }

        public ExcelOperationResult(ResultType result)
        {
            Result = result;
        }

        public ExcelOperationResult() { }

        public ResultType Result { get; set; }
    }
}
