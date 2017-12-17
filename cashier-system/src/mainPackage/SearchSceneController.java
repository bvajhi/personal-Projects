package mainPackage;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
public class SearchSceneController {


    public void goBack()throws  Exception{

        Parent root = FXMLLoader.load(getClass().getResource("main.fxml"));

        //window.setScene(new Scene(root, 300, 275));
        Main.getWindow().setScene(new Scene(root, 600, 600));


    }
}
