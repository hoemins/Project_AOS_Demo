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

    // ��� �������̽��� Stack �� ��������μ� ����ص�
    public void AddCommand(ICommand newCommand)
    {
        newCommand.Execute();
        undoStack.Push(newCommand);
    }
    
    // ����� ������� �ֱ� �����ߴ� Ŀ�ǵ带 Stack���� �̾��ܰ� ���ÿ� Undo �޼��带 ȣ����
    public void UndoCommand()
    {
        ICommand latestCommand = undoStack.Pop();
        latestCommand?.Undo();
    }
}