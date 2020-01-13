using System;
using UnityEngine;
using System.Collections.Generic;

namespace PacMan
{
    public enum Inputs
    {
        W, S, A, D,
        UpArr, DownArr, LeftArr, RightArr,
        None
    };

    public enum Directions { Up, Down, Left, Right, None }

    public struct Direction
    {
        private Directions direction;

        public Direction(Directions direction)
        {
            this.direction = direction;
        }

        Directions GetDirection() { return this.direction; }

        Vector2 ToVec2()
        {
            switch (this.direction)
            {
                case Directions.Up:
                    return Vector2.up;
                case Directions.Down:
                    return Vector2.down;
                case Directions.Left:
                    return Vector2.left;
                case Directions.Right:
                    return Vector2.right;
                case Directions.None:
                    return Vector2.zero;
                default:
                    throw new Exception();
            }
        }
    }

    public struct Input
    {
        private Inputs input;

        public Input(Inputs input)
        {
            this.input = input;
        }

        static Input GetFirstKeyDown()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
                return new Input(Inputs.W);
            else if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
                return new Input(Inputs.UpArr);
            else if (UnityEngine.Input.GetKeyDown(KeyCode.A))
                return new Input(Inputs.A);
            else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
                return new Input(Inputs.LeftArr);
            else if (UnityEngine.Input.GetKeyDown(KeyCode.S))
                return new Input(Inputs.S);
            else if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
                return new Input(Inputs.DownArr);
            else if (UnityEngine.Input.GetKeyDown(KeyCode.D))
                return new Input(Inputs.D);
            else if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
                return new Input(Inputs.RightArr);
            else return new Input(Inputs.None);
        }

        static List<Input> GetAll()
        {
            //array di ritorno contenente tutti gli input in un instante
            var ret = new List<Input>(8);

            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
                ret.Add(new Input(Inputs.W));
            if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
                ret.Add(new Input(Inputs.UpArr));
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
                ret.Add(new Input(Inputs.A));
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
                ret.Add(new Input(Inputs.LeftArr));
            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
                ret.Add(new Input(Inputs.S));
            if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
                ret.Add(new Input(Inputs.DownArr));
            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
                ret.Add(new Input(Inputs.D));
            if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
                ret.Add(new Input(Inputs.RightArr));

            if (ret.Count == 0)
                ret.Add(new Input(Inputs.None));

            return ret;
        }

        Inputs ToEnum() { return this.input; }

        Direction ToDirection()
        {
            switch (this.input)
            {
                case Inputs.W:
                case Inputs.UpArr:
                    return new Direction(Directions.Up);
                case Inputs.S:
                case Inputs.DownArr:
                    return new Direction(Directions.Down);
                case Inputs.A:
                case Inputs.LeftArr:
                    return new Direction(Directions.Left);
                case Inputs.D:
                case Inputs.RightArr:
                    return new Direction(Directions.Right);
                case Inputs.None:
                    return new Direction(Directions.None);
                default:
                    throw new Exception();
            }
        }
    }
}