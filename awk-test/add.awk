BEGIN { 
    count = $2 
}

count += $2 

END { 
    print "Total " count
}