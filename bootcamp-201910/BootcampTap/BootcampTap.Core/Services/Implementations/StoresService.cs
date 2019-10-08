using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BootcampTap.Core.Models;
using BootcampTap.Core.Services.Abstractions;
using Newtonsoft.Json;

namespace BootcampTap.Core.Services.Implementations
{
    public class StoresService : IStoresService
    {
        private readonly IHttpRequestService _httpRequestService;

        public StoresService(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
        }

        public Task<List<Store>> GetStoresAsync(CancellationToken ct = default)
        {
            //return _httpRequestService.GetAsync<List<Store>>("stores", ct);
            return Task.FromResult(GetStores());
        }

        public async Task<Store> GetStoreByIdAsync(string storeId, CancellationToken ct = default)
        {
            var storeList = await _httpRequestService.GetAsync<List<Store>>("stores", ct).ConfigureAwait(false);

            var store = storeList.FirstOrDefault(w => w.Id == storeId);

            return store;
        }

        public Task CreateStoreAsync(Store store, CancellationToken ct = default)
        {
            return _httpRequestService.PostAsync("stores", store, ct);
        }

        public Task CreateStoreAsync(string name, string address, string phone, string photoUrl, string lat, string lng,
            CancellationToken ct = default)
        {
            var store = new Store
            {
                Id = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Name = name,
                Address = address,
                Phone = phone,
                PhotoUrl = photoUrl,
                Lat = lat,
                Lng = lng
            };

            return _httpRequestService.PostAsync("stores", store, ct);
        }

        public Task DeleteStoreAsync(string storeId, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }

        public List<Store> GetStores()
        {
            var json =
                "[{\"Id\":\"1\",\"Name\":\"Xpand IT\",\"Address\":\"Rua do Mar Vermelho\",\"Phone\":\"21456892\",\"PhotoUrl\":\"https://tinyurl.com/y7rzahg4\",\"Lat\":\"38.771586\",\"Lng\":\"-9.096245\"},{\"Id\":\"20180524095211\",\"Name\":\"Unicre2\",\"Address\":\"Lisboa\",\"Phone\":\"123456789\",\"PhotoUrl\":\"kkkk\",\"Lat\":\"38.771689\",\"Lng\":\"-9.096253\"},{\"Id\":\"20180524102237\",\"Name\":\"novabase\",\"Address\":\"novabase wai\",\"Phone\":\"cenas\",\"PhotoUrl\":\"aquela\",\"Lat\":\"0\",\"Lng\":\"0\"},{\"Id\":\"20180524104719\",\"Name\":\"TOY Store i\",\"Address\":\"aaaaa\",\"Phone\":\"cc\",\"PhotoUrl\":\"bbb\",\"Lat\":\"38.771689\",\"Lng\":\"-9.096253\"},{\"Id\":\"20180524104857\",\"Name\":\"YumYum\",\"Address\":\"Rua do Mar Vermelho\",\"Phone\":\"969999999\",\"PhotoUrl\":\"https://www.mygon.com/ImageAdapterV2/shop/9584/shopimage_2.jpg\",\"Lat\":\"38.771689\",\"Lng\":\"-9.096253\"},{\"Id\":\"20180524104946\",\"Name\":\"Unicre\",\"Address\":\"Lisboa\",\"Phone\":\"777777777\",\"PhotoUrl\":\"wwwe\",\"Lat\":\"38.7711689\",\"Lng\":\"-9.096253\"},{\"Id\":\"20180524105237\",\"Name\":\"grupo Agros\",\"Address\":\"vila do conde\",\"Phone\":\"2727383\",\"PhotoUrl\":\"hjjj\",\"Lat\":\"38.771689\",\"Lng\":\"-9.096253\"},{\"Id\":\"20180524105845\",\"Name\":\"Franganito e Frangos Lta\",\"Address\":\"Rua das Couves de Lombarda\",\"Phone\":\"960000000\",\"PhotoUrl\":\"http://pudim.com.br/\",\"Lat\":\"38.7652149\",\"Lng\":\"-9.0975139\"},{\"Id\":\"20180524110024\",\"Name\":\"H3 Parque das Nacoes\",\"Address\":\"Rua do Mar Vermelho\",\"Phone\":\"969999999\",\"PhotoUrl\":\"http://casa.sapo.pt/News/multimedia/imagens/db3b049c-bd72-4c4d-8ff6-64e9e226d4c5.jpg\",\"Lat\":\"38.771689\",\"Lng\":\"-9.096253\"},{\"Id\":\"20180524115420\",\"Name\":\"Casa de Pasto\",\"Address\":\"rua arco do cego\",\"Phone\":\"916666666\",\"PhotoUrl\":\"https://lifecooler.com/files/registos/imagens/451371/399229.jpg\",\"Lat\":\"38.771689\",\"Lng\":\"-9.096253\"},{\"Id\":\"20180524115440\",\"Name\":\"Padaria Portuguesa\",\"Address\":\"Av. Dom Joao II 11701\",\"Phone\":\"969999999\",\"PhotoUrl\":\"https://www.movenoticias.com/wp-content/uploads/2017/12/padaria-portuguesa.jpg\",\"Lat\":\"38.7711802\",\"Lng\":\"-9.0978713\"},{\"Id\":\"20180524115950\",\"Name\":\"Salvador Store\",\"Address\":\"Barcelos\",\"Phone\":null,\"PhotoUrl\":\"teste\",\"Lat\":\"38.771689\",\"Lng\":\"-9.096253\"},{\"Id\":\"20180524120731\",\"Name\":\"Torre Vasco da Gama\",\"Address\":\"Torre Vasco da Gama\",\"Phone\":\"77666\",\"PhotoUrl\":\"gggg\",\"Lat\":\"38.7747796\",\"Lng\":\"-9.0917586\"},{\"Id\":\"20180524123019\",\"Name\":\"Salvador 2\",\"Address\":\"Viana do Castelo\",\"Phone\":null,\"PhotoUrl\":\"teste\",\"Lat\":\"38.771689\",\"Lng\":\"-9.096253\"},{\"Id\":\"20180524172504\",\"Name\":\"woot\",\"Address\":\"white house\",\"Phone\":\"123456789\",\"PhotoUrl\":\"https://placeimg.com/50/50/any\",\"Lat\":\"38.8976763\",\"Lng\":\"-77.0365298\"},{\"Id\":\"20180525001923\",\"Name\":\"Unicre 3\",\"Address\":\"Torre Vasco da Gama\",\"Phone\":\"666666\",\"PhotoUrl\":\"https://bit.ly/2s6sPQk\",\"Lat\":\"38.7747796\",\"Lng\":\"-9.0917586\"},{\"Id\":\"20180605153912\",\"Name\":\"Test\",\"Address\":\"Avenida da Republica\",\"Phone\":\"11111111111\",\"PhotoUrl\":\"https://backgroundimages.withfloats.com/actual/599ee9c3ec9ba60b3803533b.jpg\",\"Lat\":\"38.7407531\",\"Lng\":\"-9.1466571\"},{\"Id\":\"20180620145652\",\"Name\":\"a\",\"Address\":\"a\",\"Phone\":\"2\",\"PhotoUrl\":null,\"Lat\":null,\"Lng\":null},{\"Id\":\"20190108175016\",\"Name\":\"name\",\"Address\":\"address\",\"Phone\":\"896\",\"PhotoUrl\":\"url\",\"Lat\":null,\"Lng\":null},{\"Id\":\"20190108175104\",\"Name\":\"name1\",\"Address\":\"address\",\"Phone\":\"896\",\"PhotoUrl\":\"jol\",\"Lat\":null,\"Lng\":null},{\"Id\":\"20190109170046\",\"Name\":\"name\",\"Address\":\"address\",\"Phone\":\"789652\",\"PhotoUrl\":\"url\",\"Lat\":\"37.2631155\",\"Lng\":\"-95.5469584\"},{\"Id\":\"20190110094327\",\"Name\":\"name\",\"Address\":\"address\",\"Phone\":\"45621\",\"PhotoUrl\":\"url\",\"Lat\":\"37.2631155\",\"Lng\":\"-95.5469584\"},{\"Id\":\"20190111095816\",\"Name\":\"bershka\",\"Address\":\"Rua do mar vermelho\",\"Phone\":\"666958\",\"PhotoUrl\":\"bka\",\"Lat\":\"38.7709106\",\"Lng\":\"-9.096639\"},{\"Id\":\"20190111132514\",\"Name\":\"name\",\"Address\":\"address\",\"Phone\":\"8956\",\"PhotoUrl\":\"qa\",\"Lat\":\"10.988755\",\"Lng\":\"92.38765\"},{\"Id\":\"20190114152258\",\"Name\":\"aa\",\"Address\":\"avenida do brasil\",\"Phone\":\"789\",\"PhotoUrl\":\"url\",\"Lat\":\"38.7566849\",\"Lng\":\"-9.1402308\"},{\"Id\":\"20190115171101\",\"Name\":\"name\",\"Address\":\"address\",\"Phone\":\"589\",\"PhotoUrl\":\"joo\",\"Lat\":\"37.2631155\",\"Lng\":\"-95.5469584\"},{\"Id\":\"20190910152842\",\"Name\":\"teste2020\",\"Address\":\"teste2020\",\"Phone\":\"222333444\",\"PhotoUrl\":\"foto\",\"Lat\":\"\",\"Lng\":\"\"},{\"Id\":\"20190913112312\",\"Name\":\"xpand\",\"Address\":\"Lisboa\",\"Phone\":\"412313\",\"PhotoUrl\":\"https://homepages.cae.wisc.edu/~ece533/images/airplane.png\",\"Lat\":\"TEST_LAT\",\"Lng\":\"TEST_LNG\"},{\"Id\":\"20190917173451\",\"Name\":\"sdds\",\"Address\":\"weew\",\"Phone\":\"939\",\"PhotoUrl\":\"sdd34434\",\"Lat\":\"\",\"Lng\":\"\"},{\"Id\":\"20190917175547\",\"Name\":\"Test\",\"Address\":\"Viana\",\"Phone\":\"4344\",\"PhotoUrl\":\"sdds\",\"Lat\":\"37.7700861\",\"Lng\":\"-9.0964028\"},{\"Id\":\"20190918172141\",\"Name\":\"aaaaaaaaa\",\"Address\":\"bbbbbbbb\",\"Phone\":\"969696969\",\"PhotoUrl\":\"ffff\",\"Lat\":\"\",\"Lng\":\"\"},{\"Id\":\"20191002183534\",\"Name\":null,\"Address\":null,\"Phone\":null,\"PhotoUrl\":null,\"Lat\":null,\"Lng\":null},{\"Id\":\"20191002183810\",\"Name\":\"\",\"Address\":null,\"Phone\":null,\"PhotoUrl\":null,\"Lat\":\"\",\"Lng\":\"\"},{\"Id\":\"20191002184041\",\"Name\":\"New Store\",\"Address\":\"Rua do Mar Vermelho\",\"Phone\":\"200200200\",\"PhotoUrl\":null,\"Lat\":null,\"Lng\":null},{\"Id\":\"20191003100306\",\"Name\":\"Xpand-VC\",\"Address\":\"Rua de Fornelos\",\"Phone\":\"258111111\",\"PhotoUrl\":\"\\\"\\\"\",\"Lat\":\"41.4687147\",\"Lng\":\"-8.171368\"},{\"Id\":\"20191003131640\",\"Name\":\"Test Store\",\"Address\":\"Rua do Mar Vermelho, Lisboa\",\"Phone\":\"200200200\",\"PhotoUrl\":\"https://www.xpand-it.com/wp-content/uploads/2016/10/LogoXpandIT-2016.png\",\"Lat\":\"38.7709106\",\"Lng\":\"-9.096639\"},{\"Id\":\"20191004143753\",\"Name\":\"Xpand\",\"Address\":\"Lisboa\",\"Phone\":\"211122123\",\"PhotoUrl\":\"\\\"\\\"\",\"Lat\":\"38.7222524\",\"Lng\":\"-9.1393366\"},{\"Id\":\"20191004162204\",\"Name\":\"Worten\",\"Address\":\"Viana do Castelo\",\"Phone\":\"131312412\",\"PhotoUrl\":\"\\\"\\\"\",\"Lat\":\"41.6918046\",\"Lng\":\"-8.834451\"},{\"Id\":\"20191007105850\",\"Name\":null,\"Address\":null,\"Phone\":null,\"PhotoUrl\":null,\"Lat\":null,\"Lng\":null},{\"Id\":\"20191007105910\",\"Name\":null,\"Address\":null,\"Phone\":null,\"PhotoUrl\":null,\"Lat\":null,\"Lng\":null},{\"Id\":\"20191007105943\",\"Name\":null,\"Address\":null,\"Phone\":null,\"PhotoUrl\":null,\"Lat\":null,\"Lng\":null},{\"Id\":\"20191007134013\",\"Name\":\"VC\",\"Address\":\"Rua de Fornelos\",\"Phone\":\"912345678\",\"PhotoUrl\":\"https://tinyurl.com/guettias\",\"Lat\":\"\",\"Lng\":\"\"},{\"Id\":\"20191007145847\",\"Name\":\"4col\",\"Address\":\"Viana do Castelo\",\"Phone\":\"81238981\",\"PhotoUrl\":\"tinyurl.com/guettias\",\"Lat\":\"\",\"Lng\":\"\"}]\n";

            return JsonConvert.DeserializeObject<List<Store>>(json);
        }
    }
}