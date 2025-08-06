using EstadioIQ.BAL.Interface;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Helper.Converter;

namespace EstadioIQ.BAL.Services
{
    public class RefreeService : IRefreeService
    {
        private readonly IRefreeRepo _repo;
        private readonly RefreeConverter _converter;

        public RefreeService(IRefreeRepo repo, RefreeConverter converter)
        {
            _repo = repo;
            _converter = converter;
        }

        public ResponseData<List<RefreeDto>> GetRefrees()
        {
            var response = _repo.GetRefrees();

            List<RefreeDto> Refrees = new List<RefreeDto>();

            foreach (var Refree in response.Data)
            {
                var data = _converter.ConvertToDto(Refree);

                Refrees.Add(data);
            }

            return new ResponseData<List<RefreeDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = Refrees,
                TotalCount = response.TotalCount
            };
        }


        public ResponseData<RefreeDto> GetRefreeById(int id)
        {
            var response = _repo.GetRefreeById(id);

            RefreeDto Refree = _converter.ConvertToDto(response.Data);

            return new ResponseData<RefreeDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = Refree
            };
        }

        public ResponseData UpdateRefree(RefreeDto Refree)
        {
            var model = _converter.ConvertToModel(Refree);

            var response = _repo.UpdateRefree(model);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData AddRefree(RefreeDto Refree)
        {
            var model = _converter.ConvertToModel(Refree);

            var response = _repo.AddRefree(model);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }
    }
}
