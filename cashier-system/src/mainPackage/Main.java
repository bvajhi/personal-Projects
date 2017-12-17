package mainPackage;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

public class Main extends Application {
    private static Stage window;

    @Override
    public void start(Stage primaryStage) throws Exception{
        window = primaryStage;
        Parent root = FXMLLoader.load(getClass().getResource("main.fxml"));
        window.setTitle("Cashier");
        window.setScene(new Scene(root, 600, 600));
        window.show();
    }

    public static Stage getWindow() {
        return window;
    }

    public static void main(String[] args) {
        launch(args);
    }
}
