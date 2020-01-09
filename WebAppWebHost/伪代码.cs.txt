class AsyncMethodName : IAsyncStateMachine{
    state = -1
    void MoveNext(){ 
        try{
            if(state!=0){
                awaiter = Task.Run(SomeMethod).GetAwatier();
                AwaitUnsafeOnComplete(ref awaiter,ref stateMachine);
            }else{
                state = -1
            }
            awaiter.GetResult;
        }catch(Exception e){
            awaiter.SetException(e);
        }
    }
}