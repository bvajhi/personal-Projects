package mainPackage;

import javafx.scene.*;
import javafx.stage.*;
import javafx.scene.layout.*;
import javafx.scene.control.*;
import javafx.geometry.*;



public class messageBox {

    public static void display(String title, String message){

        final Stage window = new Stage();

        window.initModality(Modality.APPLICATION_MODAL);

        window.setTitle(title);
        window.setMinWidth(250);


        Label lable = new Label();
        lable.setText(message);

        Button close = new Button("Close");
        close.setOnAction( e-> window.close());


        VBox layout = new VBox(10);

        layout.getChildren().addAll(lable, close);
        layout.setAlignment(Pos.CENTER);


        Scene scene =new Scene(layout);

        window.setScene(scene);

        window.showAndWait();

    }


}
