package mainPackage;
import javafx.application.Application;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.TextArea;
import javafx.scene.text.Text;
import javafx.stage.Stage;



import java.awt.*;

public class MainSceneController {


        @FXML
        public TextArea cart;

        @FXML
        public TextArea upc;


    @FXML
        public void gotoSearchScene()throws  Exception{

            Parent root = FXMLLoader.load(getClass().getResource("search.fxml"));

            //window.setScene(new Scene(root, 300, 275));
            Main.getWindow().setScene(new Scene(root, 600, 400));


           // cart.insertText(0,upc.getText()+"\n" );


        }


}
