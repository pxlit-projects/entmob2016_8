package be.pxl.spring.controller;

import java.util.Date;

import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.annotation.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import be.pxl.spring.JMSSender;

@Component
@Aspect
public class LoggingAspect {
	 @Autowired
	 JMSSender jms;

	@After(value="execution(* be.pxl.spring.controller.*.*(..))")
	public void after(JoinPoint jp){		
		java.util.Date date = new Date();		
		String log = date +" : "+ jp.getTarget().getClass()+ " - " + jp.getSignature().getName()+" with "+jp.getArgs()[0];
//		System.out.println(log);
		jms.log(log);		
	}
}
