namespace GabriEShopAPI.Clients
{
    public class JsonPlaceholderResult <T> where T : class //pasakom, kad pradedam naudoti generic; kur generic yra class, ne tipas
    {
        public bool IsSuccessful {get; set;}

        public string ? ErrorMessage { get; set;}

        public T? Data { get; set;}//ir cia nurodom
    }
}
