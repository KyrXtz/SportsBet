//namespace SportsBet.Infrastructure.Consumers;
//public abstract class MessageConsumer<TMessage> : IConsumer<TMessage>
//    where TMessage : class
//{
//    private readonly IInfrastructureMetrics _metrics;

//    protected MessageConsumer(
//        IInfrastructureMetrics metrics)
//    {
//        _metrics = metrics;
//    }

//    public async Task Consume(ConsumeContext<TMessage> context)
//    {
//        var messageType = context.Message.GetType();
//        var sw = Stopwatch.StartNew();

//        try
//        {
//            await ConsumeInternal(context);

//            _metrics.RecordConsumeMessageTime(sw.ElapsedMilliseconds, messageType.FullName!);
//        }
//        catch
//        {
//            _metrics.RecordErroredConsumeMessage(sw.ElapsedMilliseconds, messageType.FullName!);
//            throw;
//        }
//    }

//    protected abstract Task ConsumeInternal(ConsumeContext<TMessage> context);
//}