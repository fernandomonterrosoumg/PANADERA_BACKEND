namespace ApiNetCore7.Models
{
    public class RespuestaHttpTipado<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public RespuestaHttpTipado(bool status, string message, T data)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }

        public static RespuestaHttpTipado<T> BuildResponse(bool isSuccess, string message, T data = default)
        {
            return new RespuestaHttpTipado<T>(isSuccess, message, data);
        }
    }

}
