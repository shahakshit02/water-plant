namespace Water_plant_BackEnd.ViewModels
{
    public class ResponseModel<T>
    {
        public bool IsSuccess
        {
            get;
            set;
        }
        public string TestingMesssage
        {
            get;
            set;
        }

        public T Data { get; set; }

    }
}
