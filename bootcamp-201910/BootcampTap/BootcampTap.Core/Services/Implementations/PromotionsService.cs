using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BootcampTap.Core.Models;
using BootcampTap.Core.Services.Abstractions;
using Newtonsoft.Json;

namespace BootcampTap.Core.Services.Implementations
{
    public class PromotionsService : IPromotionsService
    {
        private readonly IHttpRequestService _httpRequestService;

        public PromotionsService(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
        }

        public Task<List<Promotion>> GetPromotionsAsync(string storeId = null, CancellationToken ct = default)
        {
            var resource = storeId == null ? "promotions" : $"promotions/{storeId}";
            //return _httpRequestService.GetAsync<List<Promotion>>(resource, ct);
            return Task.FromResult(GetPromotions());
        }

        public Task CreatePromotionAsync(Promotion promotion, CancellationToken ct = default)
        {
            return _httpRequestService.PostAsync("promotions", promotion, ct);
        }

        public Task CreatePromotionAsync(string product, string storeId, int discount, CancellationToken ct = default)
        {
            var promotion = new Promotion
            {
                Id = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Product = product,
                Discount = discount,
                StoreId = storeId
            };

            return _httpRequestService.PostAsync("promotions", promotion, ct);
        }

        public Task DeletePromotionAsync(string promotionId, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }

        public List<Promotion> GetPromotions()
        {
            var json =
                "[{\"Id\":\"1\",\"Product\":\"Bootcamp\",\"Store\":{\"Id\":\"20180524104946\",\"Name\":\"Unicre\",\"Address\":\"Lisboa\",\"Phone\":\"777777777\",\"PhotoUrl\":\"wwwe\",\"Lat\":\"38.7711689\",\"Lng\":\"-9.096253\"},\"Discount\":40},{\"Id\":\"2\",\"Product\":\"Bootcamp 2\",\"Store\":{\"Id\":\"20180524104946\",\"Name\":\"Unicre\",\"Address\":\"Lisboa\",\"Phone\":\"777777777\",\"PhotoUrl\":\"wwwe\",\"Lat\":\"38.7711689\",\"Lng\":\"-9.096253\"},\"Discount\":70},{\"Id\":\"20180605170732\",\"Product\":\"Teste\",\"Store\":null,\"Discount\":50},{\"Id\":\"20180607110624\",\"Product\":\"Test\",\"Store\":null,\"Discount\":10},{\"Id\":\"20190109152943\",\"Product\":null,\"Store\":{\"Id\":\"1\",\"Name\":\"Xpand IT\",\"Address\":\"Rua do Mar Vermelho\",\"Phone\":\"21456892\",\"PhotoUrl\":\"https://tinyurl.com/y7rzahg4\",\"Lat\":\"38.771586\",\"Lng\":\"-9.096245\"},\"Discount\":12},{\"Id\":\"20190109153032\",\"Product\":null,\"Store\":{\"Id\":\"20180524104857\",\"Name\":\"YumYum\",\"Address\":\"Rua do Mar Vermelho\",\"Phone\":\"969999999\",\"PhotoUrl\":\"https://www.mygon.com/ImageAdapterV2/shop/9584/shopimage_2.jpg\",\"Lat\":\"38.771689\",\"Lng\":\"-9.096253\"},\"Discount\":16},{\"Id\":\"20190110162926\",\"Product\":\"aa\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190110164241\",\"Product\":\"ambushed 1\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190110164332\",\"Product\":\"testeDALC\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190111095847\",\"Product\":\"casaco\",\"Store\":{\"Id\":\"20190111095816\",\"Name\":\"bershka\",\"Address\":\"Rua do mar vermelho\",\"Phone\":\"666958\",\"PhotoUrl\":\"bka\",\"Lat\":\"38.7709106\",\"Lng\":\"-9.096639\"},\"Discount\":15},{\"Id\":\"20190114114105\",\"Product\":\"coffee\",\"Store\":{\"Id\":\"20180524104719\",\"Name\":\"TOY Store i\",\"Address\":\"aaaaa\",\"Phone\":\"cc\",\"PhotoUrl\":\"bbb\",\"Lat\":\"38.771689\",\"Lng\":\"-9.096253\"},\"Discount\":60},{\"Id\":\"20190114152326\",\"Product\":\"teste\",\"Store\":{\"Id\":\"20190114152258\",\"Name\":\"aa\",\"Address\":\"avenida do brasil\",\"Phone\":\"789\",\"PhotoUrl\":\"url\",\"Lat\":\"38.7566849\",\"Lng\":\"-9.1402308\"},\"Discount\":15},{\"Id\":\"20190910174014\",\"Product\":\"teste2020\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190912214256\",\"Product\":\"wewe\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190912214306\",\"Product\":\"4545\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190913121604\",\"Product\":\"Mac book pro\",\"Store\":null,\"Discount\":10},{\"Id\":\"20190917084920\",\"Product\":\"w34\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190917165853\",\"Product\":\"teste\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190917175314\",\"Product\":\"Test\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190917175336\",\"Product\":\"Xian’s\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190918162635\",\"Product\":\"re\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190924101521\",\"Product\":\"test\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190924150846\",\"Product\":\"Xpand\",\"Store\":null,\"Discount\":50},{\"Id\":\"20190924171728\",\"Product\":\"Product\",\"Store\":null,\"Discount\":150},{\"Id\":\"20191003100600\",\"Product\":\"Test\",\"Store\":null,\"Discount\":47},{\"Id\":\"20191007115921\",\"Product\":\"asdasdasd\",\"Store\":null,\"Discount\":1},{\"Id\":\"20191007115942\",\"Product\":\"hhhhhh\",\"Store\":null,\"Discount\":10},{\"Id\":\"20191007120151\",\"Product\":\"kjjkkjkj\",\"Store\":null,\"Discount\":11}]\n";

            return JsonConvert.DeserializeObject<List<Promotion>>(json);
        }
    }
}