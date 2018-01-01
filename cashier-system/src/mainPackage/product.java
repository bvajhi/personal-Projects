package mainPackage;

public class product {

    private int upc;
    private String name;
    private String type;
    private double price;


    public  product (int u, String n, String t, double p){
        upc= u;
        name = n;
        type= t;
        price= p;


    }


    public String getType() {
        return type;
    }

    public double getPrice() {
        return price;
    }
}
