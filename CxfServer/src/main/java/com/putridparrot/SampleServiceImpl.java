package com.putridparrot;

import sample.PurchaseOrderType;
import sample.USAddress;

public class SampleServiceImpl implements SampleService{
    public PurchaseOrderType getPurchaseOrder() {
        PurchaseOrderType po = new PurchaseOrderType();

        USAddress address = new USAddress();
        address.setCity("New York");
        address.setCountry("USA");
        address.setName("SpongeBob");

        po.setBillTo(address);

        return po;
    }
}