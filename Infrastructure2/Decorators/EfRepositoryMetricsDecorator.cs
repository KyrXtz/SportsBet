namespace SportsBet.Infrastructure.Decorators
{
    class EfRepositoryMetricsDecorator<T> : EfRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        private readonly IRepository<T> _decorated;
        private readonly IInfrastructureMetrics _metrics;

        public EfRepositoryMetricsDecorator(IRepository<T> decorated,
            IInfrastructureMetrics metrics,
            AppDbContext dbContext) : base(dbContext)
        {
            _decorated = decorated;
            _metrics = metrics;
        }

        public override async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await _decorated.UpdateAsync(entity, cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(UpdateAsync), typeof(T));
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(UpdateAsync), typeof(T));
                throw;
            }
        }

        public override async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await _decorated.UpdateRangeAsync(entities, cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(UpdateRangeAsync), typeof(T));
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(UpdateRangeAsync), typeof(T));
                throw;
            }
        }

        public override async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                var result = await _decorated.AddRangeAsync(entities, cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(AddRangeAsync), typeof(T));
                return result;
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(AddRangeAsync), typeof(T));
                throw;
            }
        }

        public override async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await _decorated.AddAsync(entity, cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(AddAsync), typeof(T));
                return result;
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(AddAsync), typeof(T));
                throw;
            }
        }

        public override async Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await _decorated.ListAsync(specification, cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(ListAsync), typeof(T));
                return result;
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(ListAsync), typeof(T));
                throw;
            }
        }

        public override async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await _decorated.ListAsync(cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(ListAsync), typeof(T));
                return result;
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(ListAsync), typeof(T));
                throw;
            }
        }
        public override async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await _decorated.CountAsync(cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(CountAsync), typeof(T));
                return result;
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(CountAsync), typeof(T));
                throw;
            }
        }
        public override async Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await _decorated.CountAsync(specification, cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(CountAsync), typeof(T));
                return result;
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(CountAsync), typeof(T));
                throw;
            }
        }
        public override async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await _decorated.AnyAsync(cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(AnyAsync), typeof(T));
                return result;
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(AnyAsync), typeof(T));
                throw;
            }
        }
        public override async Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await _decorated.AnyAsync(specification, cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(AnyAsync), typeof(T));
                return result;
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(AnyAsync), typeof(T));
                throw;
            }
        }

        public override async Task<T?> SingleOrDefaultAsync(ISingleResultSpecification<T> specification, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await _decorated.SingleOrDefaultAsync(specification, cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(SingleOrDefaultAsync), typeof(T));
                return result;
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(SingleOrDefaultAsync), typeof(T));
                throw;
            }
        }
        public override async Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await _decorated.FirstOrDefaultAsync(specification, cancellationToken);
                _metrics.RecordDatabaseTime(sw.ElapsedMilliseconds, nameof(FirstOrDefaultAsync), typeof(T));
                return result;
            }
            catch
            {
                _metrics.RecordErroredDatabaseTime(sw.ElapsedMilliseconds, nameof(FirstOrDefaultAsync), typeof(T));
                throw;
            }
        }
    }
}
