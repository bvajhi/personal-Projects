package mainPackage;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.util.ArrayList;

public class Main extends Application {
    private static Stage window;

    private static ArrayList<product> thingsInCart;

    private static double subTotal=0;
    private static double totalTax=0;
    private static double total=0;

    @Override
    public void start(Stage primaryStage) throws Exception{
        window = primaryStage;
        thingsInCart= new ArrayList <product>();

        Parent root = FXMLLoader.load(getClass().getResource("main.fxml"));

        window.setTitle("Cashier");
        window.setScene(new Scene(root, 600, 400));
        window.show();
    }

    public static Stage getWindow() {
        return window;
    }

    public static ArrayList<product> getThingsInCart() {
        return thingsInCart;
    }

    public static double getSubTotal() {
        return subTotal;
    }

    public static double getTotal() {
        return total;
    }

    public static double getTotalTax() {
        return totalTax;
    }


    public static void setSubTotal(double subTotal) {
        Main.subTotal = subTotal;
    }

    public static void setTotal(double total) {
        Main.total = total;
    }

    public static void setTotalTax(double totalTax) {
        Main.totalTax = totalTax;
    }

    public static void main(String[] args) {
        launch(args);
    }
}
