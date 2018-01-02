package mainPackage;
import javafx.application.Application;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.control.TextArea;
import javafx.scene.text.Text;
import javafx.stage.Stage;



import java.sql.*;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class MainSceneController {

    private static final String USERNAME = "root";
    private static final String PASSWORD = "";
    private static final String CONN_STRING= "jdbc:mysql://localhost/myTest";


    Connection conn = null;
    Statement stmt = null;
    ResultSet rs = null;

    HashMap<String, Double> taxInfo = createMap();

    private static HashMap<String, Double> createMap()
    {
        HashMap<String,Double> myMap = new HashMap<String,Double>();
        myMap.put("food", 0.02);
        myMap.put("clothing",0.05);
        return myMap;
    }

        @FXML
        public TextArea cart;

        @FXML
        public TextArea upc;

        @FXML
        public Label subTotal;

        @FXML
        public Label total;

        @FXML
        public Label tax;

        @FXML
        public void gotoSearchScene()throws  Exception{

            Parent root = FXMLLoader.load(getClass().getResource("search.fxml"));

            //window.setScene(new Scene(root, 300, 275));
            Main.getWindow().setScene(new Scene(root, 600, 400));


           // cart.insertText(0,upc.getText()+"\n" );


        }



        @FXML
        public void addToCartAction() throws SQLException {
            int input = Integer.parseInt( upc.getText());

            try {
                conn = DriverManager.getConnection(CONN_STRING, USERNAME, PASSWORD);
                System.out.println("Connected");

                stmt = conn.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_READ_ONLY);
                rs= stmt.executeQuery("Select * from productsInStore where upc ="+input);

                //   rs.last();

                rs.next(); // goto the 1st row

                cart.appendText(rs.getString("name")+"     "+ rs.getFloat("price")+"\n");

                product p = new product(rs.getInt("upc"), rs.getString("name"), rs.getString("type"), rs.getDouble("price"));

                Main.getThingsInCart().add(p);

                Main.setSubTotal(Main.getSubTotal()+rs.getDouble("price"));

                Main.setTotal(Main.getTotal()+rs.getDouble("price"));
                subTotal.setText("Sub Total: $ "+ Main.getSubTotal());
                total.setText("Total: $ "+Main.getTotal());

            } catch (SQLException e) {
               // e.printStackTrace();

                System.out.println("Cannot connect");
            }

            finally {
                if (conn!=null){
                    conn.close();
                }
            }


        }



        @FXML
        public  void totalAction (){

            ArrayList<product> cart = Main.getThingsInCart();
            double totalTax= 0.0;

            for (product p : cart){

                totalTax = totalTax+ (taxInfo.get(p.getType())* p.getPrice());
                totalTax = Double.parseDouble(new DecimalFormat(".##").format(totalTax));


            }



            Main.setTotalTax(totalTax);
            Main.setTotal(Main.getTotal()+totalTax);

            tax.setText("Tax: $ "+ totalTax);
            total.setText("Total: $ "+ Main.getTotal());

        }


    public void checkPriceAction() throws SQLException{


            int input = Integer.parseInt( upc.getText());

            try {
                conn = DriverManager.getConnection(CONN_STRING, USERNAME, PASSWORD);
                System.out.println("Connected");

                stmt = conn.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_READ_ONLY);
                rs= stmt.executeQuery("Select * from productsInStore where upc ="+input);

                //   rs.last();

                rs.next(); // goto the 1st row


                String message= "Product: "+ rs.getString("name")+"\nPrice: $ "+rs.getString("price");

                messageBox.display("Price", message);

            } catch (SQLException e) {
                // e.printStackTrace();

                System.out.println("Cannot connect");
            }

            finally {
                if (conn!=null){
                    conn.close();
                }
            }
    }




    public  void checkAvailability() throws SQLException{


      //  int input = Integer.parseInt( upc.getText());

        try {
            int input = Integer.parseInt( upc.getText());
            conn = DriverManager.getConnection(CONN_STRING, USERNAME, PASSWORD);
            System.out.println("Connected");

            stmt = conn.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_READ_ONLY);
            rs= stmt.executeQuery("Select * from productsInStore where upc ="+input);

            //   rs.last();

            rs.next(); // goto the 1st row


            String message= "Product: "+ rs.getString("name")+"\nQuantity: "+rs.getString("quantity");

            messageBox.display("Price", message);

        } catch (SQLException e) {
            // e.printStackTrace();

            System.out.println("Cannot connect");
        }catch (Exception i){

            messageBox.display("Error", "Number Expected");
        }


        finally {
            if (conn!=null){
                conn.close();
            }
        }


    }



}
