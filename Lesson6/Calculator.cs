﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class Calculator
    {
        public event EventHandler<EventArgs> GotResult;
        
        public float Result { get; private set; }

        public Stack<float> stack = new Stack<float>();

        public Stack<CalculatorActionLog> actionStack = new Stack<CalculatorActionLog>();

        /*---------------------Сложение------------------------------------------------*/
        public void Add(int i) // +=
        {
            try
            {
                stack.Push(Result);
                actionStack.Push(new CalculatorActionLog(CalculatorAction.Add, i));
                Result += i;
                GotResult(this, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка сложения", e, actionStack.ToList());
            }
        }

        public void Add(float i) 
        {
            try
            {
                stack.Push(Result);
                actionStack.Push(new CalculatorActionLog(CalculatorAction.Add, i));
                Result += i;
                GotResult(this, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка сложения", e, actionStack.ToList());
            }

        }

        public static float operator +(Calculator c, float val) 
        {
            try
            {
                c.stack.Push(c.Result);
                c.actionStack.Push(new CalculatorActionLog(CalculatorAction.Add, val));
                c.Result += val;
                c.GotResult(c, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка сложения", e, c.actionStack.ToList());
            }

            return val;
        }

        /*Отмена последней операции*/
        public void CancelLast()
        {
            if (stack.Count > 0)
            {
                Result = stack.Pop();
                actionStack.Pop();
                GotResult(this, new EventArgs());
            }
        }

        /*----------Деление-------------------*/
        public void Div(int i)
        {
            try
            {
                stack.Push(Result);
                actionStack.Push(new CalculatorActionLog(CalculatorAction.Div, i));

                Result /= i;
                GotResult(this, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка деления", e, actionStack.ToList());
            }
        }

        public void Div(float i)
        {
            try
            {
                stack.Push(Result);
                actionStack.Push(new CalculatorActionLog(CalculatorAction.Div, i));

                Result /= i;
                GotResult(this, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка деления", e, actionStack.ToList());
            }
        }

        public static float operator /(Calculator c, float val) 
        {
            try
            {
                c.stack.Push(c.Result);
                c.actionStack.Push(new CalculatorActionLog(CalculatorAction.Add, val));
                c.Result /= val;
                c.GotResult(c, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка деления", e, c.actionStack.ToList());
            }

            return val;
        }

        /*--------------Умножение---------------*/
        public void Mul(int i)
        {
            try
            {
                stack.Push(Result);
                actionStack.Push(new CalculatorActionLog(CalculatorAction.Mul, i));
                Result *= i;
                GotResult(this, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка умножения", e, actionStack.ToList());
            }
        }

        public void Mul(float i)
        {
            try
            {
                stack.Push(Result);
                actionStack.Push(new CalculatorActionLog(CalculatorAction.Mul, i));
                Result *= i;
                GotResult(this, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка умножения", e, actionStack.ToList());
            }
        }

        public static float operator *(Calculator c, float val) 
        {
            try
            {
                c.stack.Push(c.Result);
                c.actionStack.Push(new CalculatorActionLog(CalculatorAction.Add, val));
                c.Result *= val;
                c.GotResult(c, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка умножения", e, c.actionStack.ToList());
            }

            return val;
        }

        /*----Вычитание----------------------------*/
        public void Sub(int i)
        {
            try
            {
                stack.Push(Result);
                actionStack.Push(new CalculatorActionLog(CalculatorAction.Sub, i));

                Result -= i;
                GotResult(this, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка вычитания", e, actionStack.ToList());
            }
        }

        public void Sub(float i)
        {
            try
            {
                stack.Push(Result);
                actionStack.Push(new CalculatorActionLog(CalculatorAction.Sub, i));

                Result -= i;
                GotResult(this, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка вычитания", e, actionStack.ToList());
            }
        }

        public static float operator -(Calculator c, float val) 
        {
            try
            {
                c.stack.Push(c.Result);
                c.actionStack.Push(new CalculatorActionLog(CalculatorAction.Add, val));
                c.Result -= val;
                c.GotResult(c, new EventArgs());
            }
            catch (Exception e)
            {
                throw new CalculatorException("Ошибка вычитания", e, c.actionStack.ToList());
            }

            return val;
        }

    }
}
