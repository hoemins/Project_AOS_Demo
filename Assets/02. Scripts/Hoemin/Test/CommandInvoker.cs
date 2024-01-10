using Hoemin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    Stack<ICommand> undoStack;
    
    public CommandInvoker()
    {
        undoStack = new Stack<ICommand>();
    }

    // 명령 인터페이스를 Stack 에 담아줌으로서 기록해둠
    public void AddCommand(ICommand newCommand)
    {
        newCommand.Execute();
        undoStack.Push(newCommand);
    }
    
    // 명령을 취소했을 최근 실행했던 커맨드를 Stack에서 뽑아줌과 동시에 Undo 메서드를 호출함
    public void UndoCommand()
    {
        ICommand latestCommand = undoStack.Pop();
        latestCommand?.Undo();
    }
}