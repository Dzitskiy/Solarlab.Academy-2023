using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Contexts.Files.Repositories;
using Board.Contracts.File;
using Board.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.DataAccess.Contexts.Files.Repository
{
    /// <inheritdoc cref="IFileRepository"/>
    public class FileRepository : IFileRepository
    {
        private readonly IRepository<Domain.Files.File> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализация экземпляра <see cref="FileRepository"/>.
        /// </summary>
        public FileRepository(IRepository<Domain.Files.File> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var file = await _repository.GetByIdAsync(id, cancellationToken);
            if (file == null)
            {
                return;
            }

            await _repository.DeleteAsync(file, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<FileDto> DownloadAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(x => x.Id == id)
                              .ProjectTo<FileDto>(_mapper.ConfigurationProvider)
                              .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<FileInfoDto> GetInfoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(x => x.Id == id)
                              .ProjectTo<FileInfoDto>(_mapper.ConfigurationProvider)
                              .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<Guid> UploadAsync(Domain.Files.File model, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(model, cancellationToken);
            return model.Id;
        }
    }
}
