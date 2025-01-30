using Modmon.Modules.Conferences.Core.DTO;
using Modmon.Modules.Conferences.Core.Exceptions;
using Modmon.Modules.Conferences.Core.Mappers;
using Modmon.Modules.Conferences.Core.Policies;
using Modmon.Modules.Conferences.Core.Repositories;

namespace Modmon.Modules.Conferences.Core.Services
{
    internal class HostService : IHostService
    {
        private readonly IHostRepository _hostRepository;
        private readonly IHostDeletePolicy _hostDeletePolicy;

        public HostService(IHostRepository hostRepository,
            IHostDeletePolicy hostDeletePolicy)
        {
            _hostRepository = hostRepository;
            _hostDeletePolicy = hostDeletePolicy;
        }

        public async Task<HostDetailsDto> GetAsync(Guid id)
        {
            var host = await _hostRepository.GetAsync(id);
            if (host == null) throw new HostNotFoundException(id);
            return host.ToDetailsDto();
        }
        public async Task AddAsync(HostDto dto)
        {
           await _hostRepository.AddAsync(dto.ToEntity(Guid.NewGuid()));
        }

        public async Task<IReadOnlyList<HostDto>> BrowseAsync()
        {
            var hosts = await _hostRepository.BrowseAsync();
            return hosts.Select(x => x.ToDto()).ToList();
        }

        public async Task DeleteAsync(Guid id)
        {
            var host = await _hostRepository.GetAsync(id);
            if (host == null) throw new HostNotFoundException(id);

            if (await _hostDeletePolicy.CanDeleteAsync(host) is false)
                throw new CannotDeleteHostException(id);

            await _hostRepository.DeleteAsync(host);
        }


        public async Task UpdateAsync(HostDetailsDto dto)
        {
            var host = await _hostRepository.GetAsync(dto.Id);
            if (host == null) throw new HostNotFoundException(dto.Id);

            host.Name = dto.Name;
            host.Description = dto.Description;


            await _hostRepository.UpdateAsync(host);
        }
    }
}