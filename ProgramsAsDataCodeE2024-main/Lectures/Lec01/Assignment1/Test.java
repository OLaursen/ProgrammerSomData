public class Test{
    public static void main(String[] args){
        Expr e = new Add(new CstI(17), new Var("z"));
        System.out.println(e.toString());
    }
}

abstract class Expr{}

class CstI extends Expr{
    protected final int i;

    public CstI(int i){
        this.i = i;
    }

    @Override
    public String toString() {
        return Integer.toString(i);
    }
}

class Var extends Expr{
    protected final String name;
    public Var(String name){
        this.name = name;
    }

    @Override
    public String toString(){  
        return name;
    }
}

abstract class Binop extends Expr{
    protected final String oper;
    protected final Expr e1, e2;
    public Binop(String oper, Expr e1, Expr e2){
        this.oper = oper;
        this.e1 = e1;
        this.e2 = e2;
    }
    @Override
    public String toString(){
        return "(" + e1.toString() + " " + oper + " " + e2.toString() + ")";
    }
}

class Add extends Binop{
    public Add(Expr e1, Expr e2){
        super("+", e1, e2);
    }
    @Override
    public String toString(){
        return "(" + e1.toString() + " + " + e2.toString() + ")";
    }

}

class Sub extends Binop{
    public Sub(Expr e1, Expr e2){
        super("-", e1, e2);
    }
    @Override
    public String toString(){
        return "(" + e1.toString() + " - " + e2.toString() + ")";
    }

}

class Mul extends Binop{
    public Mul(Expr e1, Expr e2){
        super("*", e1, e2);
    }
    @Override
    public String toString(){
        return "(" + e1.toString() + " * " + e2.toString() + ")";
    }
}