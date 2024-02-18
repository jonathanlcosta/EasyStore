namespace EasyStore.Shared.Utils.Consultas
{
    public class PaginacaoConsulta<T> where T : class
    {
        public long Total { get; set; }
        public IEnumerable<T> Registros { get; set; }
    }
}