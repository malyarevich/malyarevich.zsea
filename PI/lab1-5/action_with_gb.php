<?php
require_once 'dbconnect.php';

// получаем переменные из формы

$msg    = $_REQUEST['msg'];
$action = $_REQUEST['action'];

$query = mysqli_query($link1, "SELECT ID, nickname, path FROM users WHERE ID = '" . $_COOKIE["id"] . "' AND user_hash = '" . $_COOKIE['hash'] . "';");

$data = mysqli_fetch_assoc($query);

$user_id  = $data['ID'];
$nickname = $data['nickname'];
$path     = $data['path'];

if ($action == "add") {
    // добавление данных в БД 
    $sql = "INSERT INTO gb(user_id, nickname, path, dt, msg) VALUES ('$user_id', '$nickname', '$path', NOW(), '$msg')";
    $r   = mysqli_query($link1, $sql);
}

if ($action == "delete") {
    // удаление базы гостевой
    $sql = "DELETE FROM gb";
    $r   = mysqli_query($link1, $sql);
}

header("Location: guestbook.php");
?>