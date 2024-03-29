package be.pxl.spring.controller;

import java.sql.Timestamp;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import be.pxl.spring.domain.Session;
import be.pxl.spring.service.SessionService;

@RestController
@RequestMapping(value="/session", produces="application/json")
public class SessionRestController {

	@Autowired
	private SessionService sessionservice;
	
	@RequestMapping(method = RequestMethod.GET, value = "{id}")
	public ResponseEntity<Session> getSessionById(@PathVariable("id") int id){		

		Session s = sessionservice.findOne(id);
		HttpStatus status = HttpStatus.OK;
		if(s == null){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<Session>(s, status);
		
	}
	@RequestMapping(method = RequestMethod.POST)
	@Secured({"ROLE_ADMIN"})
	public int updateSession(@RequestBody Session s){
		sessionservice.save(s);
		sessionservice.flush();
		return s.getSessionId();
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByUserId/{userId}")
	public ResponseEntity<List<Session>> getSessionsByUserId(@PathVariable("userId") int userId){
		List<Session> sessionList = sessionservice.findByUserId(userId);
		HttpStatus status = HttpStatus.OK;
		if(sessionList == null || sessionList.isEmpty()){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<List<Session>>(sessionList, status);
		
	}
	@RequestMapping(method = RequestMethod.POST, value = "ByDate")
	public ResponseEntity<List<Session>> getSessionsByDate(@RequestBody Timestamp timeStamp){
		List<Session> sessionList =  sessionservice.findByDate(timeStamp);
		HttpStatus status = HttpStatus.OK;
		if(sessionList == null || sessionList.isEmpty()){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<List<Session>>(sessionList, status);
		
	}
	
	@RequestMapping(method = RequestMethod.POST, value = "ByGreaterStart")
	public ResponseEntity<List<Session>> getSessionsByGreaterStartTime(@RequestBody Timestamp timeStamp){
		List<Session> sessionList = sessionservice.findByGreaterStartTime(timeStamp);
		HttpStatus status = HttpStatus.OK;
		if(sessionList == null || sessionList.isEmpty()){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<List<Session>>(sessionList, status);
		
	}
	@RequestMapping(method = RequestMethod.POST, value = "ByLesserEnd")
	public ResponseEntity<List<Session>> getSessionsByLesserEndTime(@RequestBody Timestamp timeStamp){
		List<Session> sessionList = sessionservice.findByLesserEndTime(timeStamp);
		HttpStatus status = HttpStatus.OK;
		if(sessionList == null || sessionList.isEmpty()){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<List<Session>>(sessionList, status);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByGreaterActual/{time}")
	public ResponseEntity<List<Session>> getSessionsByGreaterActualTime(@PathVariable("time") int time){
		List<Session> sessionList = sessionservice.findByGreaterActualTime(time);
		HttpStatus status = HttpStatus.OK;
		if(sessionList == null || sessionList.isEmpty()){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<List<Session>>(sessionList, status);

		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByLesserActual/{time}")
	public ResponseEntity<List<Session>> getSessionsByLesserActualTime(@PathVariable("time") int time){
		List<Session> sessionList = sessionservice.findByLesserActualTime(time);
		HttpStatus status = HttpStatus.OK;
		if(sessionList == null || sessionList.isEmpty()){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<List<Session>>(sessionList, status);
		
	}
	@RequestMapping(method = RequestMethod.POST, value = "Between}")
	public List<Session> getSessionsBetween(@RequestBody Timestamp startTime,
			@RequestBody Timestamp endTime ){
		
		return sessionservice.findBetween(startTime, endTime);
		
	}
	@RequestMapping(method = RequestMethod.DELETE)
	@Secured({"ROLE_ADMIN"})
	public void deleteSession(@RequestBody Session s){
		sessionservice.delete(s);
	}
	@RequestMapping(method = RequestMethod.POST, value="AverageActualTime")
	public double getAverageActualTime(@RequestBody Timestamp startTime,
			@RequestBody Timestamp endTime ){
		
				return sessionservice.getAverageActualTime(startTime, endTime);
		
	}
	
	@RequestMapping(method = RequestMethod.GET, value="LastSession/{id}")
	public ResponseEntity<Session> getLastSession(@PathVariable("id") int userId){
		Session s = sessionservice.getLastSession(userId);
		HttpStatus status = HttpStatus.OK;
		if(s == null){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<Session>(s, status);
	}
	@RequestMapping(method = RequestMethod.GET, value="FirstSession/{id}")
	public ResponseEntity<Session> getFirstSession(@PathVariable("id") int userId){
		Session s = sessionservice.getFirstSession(userId);
		HttpStatus status = HttpStatus.OK;
		if(s == null){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<Session>(s, status);
	}
}
