<?php
    $destino="xp123xd@gmail.com";
    $nombre = $_POST["nombre"];
    $correo = $_POST["correo"];
    $descripcion = $_POST["descripcion"];
    $tipo = $_POST["tipo"];
    $contenido = "Nombre : " . $nombre . "\nCorreo : " . $correo .  "\nDescripcion : " . $descripcion . "\ntipo : " . $tipo ;
    mail($destino,"Contacto",$contenido);
    header(Location: Index.html);
?>