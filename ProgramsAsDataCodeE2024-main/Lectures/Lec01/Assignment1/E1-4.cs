using System.Collections.Generic;

public class E14
{

    public static Dictionary<string, int> env = new Dictionary<string, int>();

    public static void Main(string[] args)
    {


        env.Add("a", 3);
        env.Add("c", 78);
        env.Add("baf", 666);
        env.Add("b", 111);

        Expr e0 = new Add(new CstI(1), new Mul(new CstI(2), new CstI(3)));
        Console.WriteLine(e0.ToString());
        Expr e1 = new Sub(new CstI(5), new Mul(new CstI(4), new CstI(3)));
        Console.WriteLine(e1.ToString());
        Expr e2 = new Mul(new CstI(5), new Add(new CstI(7), new CstI(8)));
        Console.WriteLine(e2.ToString());
        Expr e3 = new Add(new Mul(new CstI(9), new CstI(3)), new CstI(4));
        Console.WriteLine(e3.ToString());
        Console.WriteLine(e3.Eval(env));
        Expr e4 = new Mul(new Add(new CstI (1), new CstI (0)), new Sub(new Var ("x"), new CstI (0)));;
        Console.WriteLine(e4.ToString());
        Console.WriteLine(e4.Simplify());
    }
}


abstract class Expr{
    public abstract int Eval(Dictionary<string, int> env);
    public abstract override string ToString();
    public abstract Expr Simplify();
}
class CstI : Expr{
    protected readonly int i;
    public CstI(int i){
        this.i = i;
    }
    public override int Eval(Dictionary<string, int> env){
        return i;
    }
    public override string ToString(){
        return i.ToString();
    }

    public int getValue(){
        return i;
    }

    public override Expr Simplify(){
        return this;
    }
}

class Var : Expr{
    protected readonly string name;
    public Var(string name){
        this.name = name;
    }
    public override string ToString(){  
        return name;
    }
    public override int Eval(Dictionary<string, int> env){
        return env[name];
    }

    public override Expr Simplify(){
        return this;
    }
}

class Binop : Expr{
    protected readonly string oper;
    public readonly Expr e1, e2;
    public Binop(string oper, Expr e1, Expr e2){
        this.oper = oper;
        this.e1 = e1;
        this.e2 = e2;
    }

    public override string ToString(){
        return "(" + e1.ToString() + " " + oper + " " + e2.ToString() + ")";
    }
    public override int Eval(Dictionary<string, int> env){
        int v1 = e1.Eval(env);
        int v2 = e2.Eval(env);
        switch(oper){
            case "+": return v1 + v2;
            case "-": return v1 - v2;
            case "*": return v1 * v2;
            default: throw new Exception("Unknown operator: " + oper);
        }
    }
    public override Expr Simplify(){
        Expr e1s = e1.Simplify();
        Expr e2s = e2.Simplify();
        return new Binop(oper, e1s, e2s);
    }
}

class Add : Binop{
    public Add(Expr e1, Expr e2) : base("+", e1, e2){
    }
    public override string ToString(){
        return "(" + e1.ToString() + " + " + e2.ToString() + ")";
    }

    public override Expr Simplify(){
        Expr e1s = e1.Simplify();
        Expr e2s = e2.Simplify();
        if (e1s is CstI c1 && c1.getValue() == 0) {
            return e2s;
        }

        if (e2s is CstI c2 && c2.getValue() == 0) {
            return e1s;
        }
        return this;
    }
}

class Sub : Binop{
    public Sub(Expr e1, Expr e2) : base("-", e1, e2){
    }
    public override string ToString(){
        return "(" + e1.ToString() + " - " + e2.ToString() + ")";
    }

    public override Expr Simplify(){
        Expr e1s = e1.Simplify();
        Expr e2s = e2.Simplify();
        if (e2s is CstI c1 && c1.getValue() == 0) {
            return e1;
        }
        if (e1s is CstI c2 && e2s is CstI c3 && c2.getValue() == c3.getValue()) {
            return new CstI(0);
        }
        return this;
    }
}

class Mul : Binop{
    public Mul(Expr e1, Expr e2) : base("*", e1, e2){
    }

    public override string ToString(){
        return "(" + e1.ToString() + " * " + e2.ToString() + ")";
    }

    public override Expr Simplify(){
        Expr e1s = e1.Simplify();
        Expr e2s = e2.Simplify();
        if ((e1s is CstI c1 && c1.getValue() == 0) || (e2s is CstI c2 && c2.getValue() == 0)) {
            return new CstI(0);
        }
        if (e1s is CstI c3 && c3.getValue() == 1) {
            return e2s;
        }
        if (e2s is CstI c4 && c4.getValue() == 1) {
            return e1s;
        }
        return this;
    }
}

