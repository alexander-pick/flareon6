<?php
// emualtes the activation answer of the CNC server

    $key = "M";
    $text = "orange mocha frappuccino\0orange mocha frappuccino";
    $outText = '';
    for($i=0; $i<strlen($text); $i++ )
    {
            $outText .= ($text[$i] ^ $key);
    }
    echo(base64_encode($outText));

$postdata = file_get_contents("php://input");
file_put_contents('request.log', $postdata."\n", FILE_APPEND);
file_put_contents('request.log', base64_decode($postdata)."\n\n", FILE_APPEND);

?>
