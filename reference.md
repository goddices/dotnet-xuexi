# async/await keywords

https://www.codeproject.com/Articles/31971/Understanding-SynchronizationContext-Part-I

TaskSchedulerTaskScheduler，它决定了task该如何被调度，而在.net framework中有两种系统定义Scheduler，
第一个是Task默认的ThreadPoolTaskScheduler，还是一种SynchronizationContextTaskScheduler，
以及这两种类型之外的如何自定义