<?php
require_once 'dbconnect.php';
/* border auth */

/* func gen rnd str*/
function generateCode($length = 6)
{
    
    $chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHI JKLMNOPRQSTUVWXYZ0123456789";
    
    $code = "";
    
    $clen = strlen($chars) - 1;
    while (strlen($code) < $length) {
        
        $code .= $chars[mt_rand(0, $clen)];
    }
    
    return $code;
    
}

if (isset($_POST['submit'])) {

    
    /*login*/
    
    $query = mysqli_query($link1, "SELECT ID, nickname, role, PASSWORD FROM users WHERE nickname='" . mysqli_real_escape_string($link1, $_POST['nickname']) . "' LIMIT 1");
    
    $data = mysqli_fetch_assoc($query);
    
    
    /*equal pass*/
    
    if ($data['PASSWORD'] == md5(md5($_POST['password']))) {
        
        /*gen rnd numb*/
        
        $hash = md5(generateCode(10));
        
/*
        $ip = get_ip();
        
        $opt       = array(
            'flags' => 'FILTER_FLAG_IPV4'
        );
        $result_ip = filter_var($ip, FILTER_VALIDATE_IP, $opt);
        
        $ips = explode(" ", $allowed_ips);
        if (strlen($result_ip) == 0 || array_search($_SERVER["REMOTE_ADDR"], $ips) === FALSE) {
           header("Location: ./index.php");
            exit();
        }*/
        
        /*hash auth*/
        /*
        mysqli_query($link1, "UPDATE users SET IP_ADDRESS = '$ip', user_hash='" . $hash . "' " . $insip . " WHERE ID='" . $data['ID'] . "'");
        */
        
        /*equal cookie*/
        
        
        setcookie("id", $data['ID'], time() + 60 * 60 * 24 * 30);
        
        setcookie("nickname", $data['nickname'], time() + 60 * 60 * 24 * 30);
        
        setcookie("role", $data['role'], time() + 60 * 60 * 24 * 30);
        
        setcookie("hash", $hash, time() + 60 * 60 * 24 * 30);
        
        
        
        /*relocate*/
        
        header("Location: ./index.php");
        exit();
        
    } else {
        
        
        
        setcookie("id", "", time() - 3600);
        
        setcookie("nickname", "", time() - 3600);
        
        setcookie("role", "", time() - 3600);
        
        setcookie("hash", "", time() - 3600);
        
        header("Location: ./index.php");
        exit();
        
    }
    
}

?>