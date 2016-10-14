package be.pxl.spring.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import be.pxl.spring.domain.Session;
import be.pxl.spring.repository.*;
import be.pxl.spring.service.SessionService;

@RestController
@RequestMapping(value="/session", produces="application/json")
public class SessionRestController {

	@Autowired
	private SessionService sessionservice;
	
	@RequestMapping(method = RequestMethod.GET, value = "{id}")
	public Session getSessionById(@PathVariable("id") int id){		
		return sessionservice.findOne(id);
		
	}
	@RequestMapping(method = RequestMethod.POST, value="{s}")
	public void updateSession(@PathVariable("s") Session s){
		sessionservice.save(s);
		
	}
}
